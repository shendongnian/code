    [SecuritySafeCritical]
    public virtual void WriteLine(string value)
    {
        if (value == null)
        {
            this.WriteLine();
        }
        else
        {
            int length = value.Length;
            int num2 = this.CoreNewLine.Length;
            char[] destination = new char[length + num2];
            value.CopyTo(0, destination, 0, length);
            switch (num2)
            {
                case 2:
                    destination[length] = this.CoreNewLine[0];
                    destination[length + 1] = this.CoreNewLine[1];
                    break;
    
                case 1:
                    destination[length] = this.CoreNewLine[0];
                    break;
    
                default:
                    Buffer.InternalBlockCopy(this.CoreNewLine, 0, destination, length * 2, num2 * 2);
                    break;
            }
            this.Write(destination, 0, length + num2);
        }
    }
