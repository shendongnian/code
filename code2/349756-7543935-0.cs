        // A StreamWriter that does not escape &#10; characters
        public class NonXmlEscapingStreamWriter : StreamWriter
        {
            private const string AmpToken = "amp";
            private int _bufferState = 0; // used to keep state
            // add other ctors overloads if needed
            public NonXmlEscapingStreamWriter(string path)
                : base(path)
            {
            }
            // NOTE this code is based on the assumption that StreamWriter
            // only overrides these 4 Write functions, which is true today but could change in the future
            // and also on the assumption that the XmlTextWrite writes escaped values in a specific WriteXX calls sequence
            public override void Write(char value)
            {
                if (value == '&')
                {
                    if (_bufferState == 0)
                    {
                        _bufferState++;
                        return; // hold it
                    }
                    else
                    {
                        _bufferState = 0;
                    }
                }
                else if (value == ';')
                {
                    if (_bufferState > 1)
                    {
                        _bufferState++;
                        return;
                    }
                    else
                    {
                        Write('&'); // release what's been held
                        Write(AmpToken);
                        _bufferState = 0;
                    }
                }
                else if (value == '\n') // detect non escaped \n
                {
                    base.Write("&#10;");
                    return;
                }
                base.Write(value);
            }
            public override void Write(string value)
            {
                if (_bufferState > 0)
                {
                    if (value == AmpToken)
                    {
                        _bufferState++;
                        return; // hold it
                    }
                    else
                    {
                        Write('&'); // release what's been held
                        _bufferState = 0;
                    }
                }
                base.Write(value);
            }
            public override void Write(char[] buffer, int index, int count)
            {
                if (_bufferState > 2)
                {
                    _bufferState = 0;
                    base.Write('&'); // release this anyway
                    string replace;
                    if ((buffer != null) && ((replace = GetReplaceLength(buffer, index, count)) != null))
                    {
                        base.Write(replace);
                        base.Write(buffer, index + replace.Length, count - replace.Length);
                        return;
                    }
                    else
                    {
                        base.Write(AmpToken); // release this
                        base.Write(';'); // release this
                    }
                }
                base.Write(buffer, index, count);
            }
            public override void Write(char[] buffer)
            {
                Write(buffer, 0, buffer != null ? buffer.Length : 0);
            }
            private string GetReplaceLength(char[] buffer, int index, int count)
            {
                // this is specific to the 10 character but could be adapted
                const string token = "#10;";
                if ((index + count) < token.Length)
                    return null;
                // we test the char array to avoid string allocations
                for(int i = 0; i < token.Length; i++)
                {
                    if (buffer[index + i] != token[i])
                        return null;
                }
                return token;
            }
        }
