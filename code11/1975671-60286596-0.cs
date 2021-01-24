    static string ExtractInnerJsonObject(ReadOnlySpan<byte> jsonPayload, ReadOnlySpan<char> targetField, bool preserveWhiteSpaces = false)
    {
        const int TYPE_OTHER = 0;
        const int TYPE_OBJECT = 1;
        const int TYPE_STRING = 2;
        const int TYPE_ARRAY = 3;
                
        ReadOnlySpan<char> jsonPayloadString = Encoding.UTF8.GetString(jsonPayload).AsSpan();
    
        int objectDepth = 0;
        int lastWhiteSpacePosition = 0;
        int fieldNameStartPosition = 0;
        int fieldNameEndPosition = 0;
        int valueStartPosition = 0;
        int valueEndPosition = 0;
        int detectedValueType = TYPE_OTHER;
    
        bool isValueTypeDetected = false;
    
        bool isValueScanStarted = false;
        bool isValueScanCompleted = false;
    
        bool isTargetField = false;
        bool isFieldNameScanStarted = false;
        bool isFieldNameScanCompleted = false;
                
    
        for (int i = 0; i < jsonPayloadString.Length; i++)
        {
            char c = jsonPayloadString[i];
    
            if (c == '{')
            {
                objectDepth++;
    
                if (isValueScanStarted && !isValueScanCompleted && !isValueTypeDetected)
                {
                    detectedValueType = TYPE_OBJECT;
                    isValueTypeDetected = true;
                }
            }
            else if (c == '}')
            {
                objectDepth--;
    
                if (isValueScanStarted && !isValueScanCompleted && detectedValueType == TYPE_OBJECT && objectDepth == 1)
                {
                    valueEndPosition = i;
                    isValueScanCompleted = true;
                }
    
                if (isValueScanStarted && !isValueScanCompleted && detectedValueType == TYPE_OTHER)
                {
                    valueEndPosition = i - 1;
                    isValueScanCompleted = true;
                }
            }
            else if (c == '"')
            {
                if (!isValueScanStarted)
                {
                    if (!isFieldNameScanStarted)
                    {
                        fieldNameStartPosition = i + 1;
                        isFieldNameScanStarted = true;
                    }
                    else
                    {
                        fieldNameEndPosition = i - 1;
                        isFieldNameScanCompleted = true;
                    }
                }
                else
                {
                    if (!isValueTypeDetected)
                    {
                        detectedValueType = TYPE_STRING;
                        isValueTypeDetected = true;
                    }
                    else
                    {
                        if (!isValueScanCompleted && detectedValueType == TYPE_STRING)
                        {
                            valueEndPosition = i;
                            isValueScanCompleted = true;
                        }
                    }
                }
            }
            else if (c == ':')
            {
                if (!isValueScanStarted)
                {
                    valueStartPosition = i + 1;
                    isValueScanStarted = true;
                }
            }
            else if (c == ',')
            {
                if (isValueScanStarted && !isValueScanCompleted && detectedValueType == TYPE_OTHER)
                {
                    valueEndPosition = i - 1;
                    isValueScanCompleted = true;
                }
            }
            else if (c == '[')
            {
                if (isValueScanStarted && !isValueScanCompleted && !isValueTypeDetected)
                {
                    detectedValueType = TYPE_ARRAY;
                    isValueTypeDetected = true;
                }
            }
            else if (c == ']')
            {
                if (isValueScanStarted && !isValueScanCompleted && detectedValueType == TYPE_ARRAY)
                {
                    valueEndPosition = i;
                    isValueScanCompleted = true;
                }
            }
            else if (char.IsWhiteSpace(c))
            {
                lastWhiteSpacePosition = i;
            }
    
            if (isFieldNameScanStarted && isFieldNameScanCompleted)
            {
                ReadOnlySpan<char> fieldName = jsonPayloadString[fieldNameStartPosition..(fieldNameEndPosition + 1)];
    
                if (fieldName.Equals(targetField, StringComparison.Ordinal))
                {
                    isTargetField = true;
                }
    
                isFieldNameScanStarted = false;
                isFieldNameScanCompleted = false;
            }
    
            if (isValueScanStarted && isValueScanCompleted)
            {
                if (isTargetField)
                {
                    ReadOnlySpan<char> value = jsonPayloadString[valueStartPosition..(valueEndPosition + 1)];
    
                    if (preserveWhiteSpaces)
                    {
                        return value.ToString();
                    }
                    else
                    {
                        return value.ToString().Trim();
                    }
                }
    
                isValueScanStarted = false;
                isValueScanCompleted = false;
                isValueTypeDetected = false;
                detectedValueType = TYPE_OTHER;
            }
    
        }
    
        return null;
    }
