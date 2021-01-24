    StatusCode _errorStatus = _session.Call(_objectId, _methodId, _inputArguments, out _inputArgumentStatus, out _outputArguments);
    
                DataTypeManager _dataTypeManager = new DataTypeManager(_session);
                DataValue _dataValue = new DataValue(_outputArguments[1]);
                Variant value = _dataValue.WrappedValue;
                ExtensionObject _extensionObject = value.ToExtensionObject();
                GenericEncodeableObject _genericEncodeable = _dataTypeManager.ParseValue(_extensionObject);
    
                GenericStructureDataType _genericStructuredDataType = _genericEncodeable.TypeDefinition;
    
                object _decodedOutput = RecurssiveDecode(_genericEncodeable, 4); 
    
    /// <summary>
            /// Decodes a complex opc ua object
            /// </summary>
            /// <param name="genericEncodeable">Object to decode.</param>
            /// <param name="index">Argument in object to decode and retrieve.</param>
            /// <returns></returns>
            object RecurssiveDecode(GenericEncodeableObject genericEncodeable, int index = 0)
            {
                GenericStructureDataType _genericStructuredDataType = genericEncodeable.TypeDefinition;
                for (int i = index; i < _genericStructuredDataType.Count; i++)
                {
                    // Get the description of the field (name, data type etc.)
                    GenericStructureDataTypeField _fieldDescription = _genericStructuredDataType[i];
                    // Get the value of the field
                    Variant fieldValue = genericEncodeable[i];
                    string fieldName = _fieldDescription.Name;
    
                    if (_fieldDescription.ValueRank == -1)
                    {
                        if (_fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Simple)
                        {
                            // Print the name and the value
                            string fieldValueString = fieldValue.ToString();
                            return fieldValueString;
                        }
                        else if (_fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Structured)
                        {
                            // Print the name and call this method again the child
                            RecurssiveDecode((GenericEncodeableObject)fieldValue.GetValue<GenericEncodeableObject>(null));
                        }
                    }
                    else if (_fieldDescription.ValueRank == 1)
                    {
                        // Print the fields name
    
                        if (_fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Simple)
                        {
                            // Print each element
                            Array array = fieldValue.Value as Array;
                            return array;
                        }
                        else if (_fieldDescription.TypeDescription.TypeClass == GenericDataTypeClass.Structured)
                        {
                            // Call this method again foreach element
                            ExtensionObjectCollection extensionObjects = fieldValue.ToExtensionObjectArray();                        
                            foreach (ExtensionObject e in extensionObjects)
                            {
                                RecurssiveDecode((GenericEncodeableObject)fieldValue.GetValue<GenericEncodeableObject>(null));
                            }
                        }
                    }
                }
                return null;
            }
