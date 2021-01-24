    [System.Runtime.InteropServices.ComVisible(false)]
            public StringBuilder AppendLine(string value) {
                Contract.Ensures(Contract.Result<StringBuilder>() != null);
                Append(value);
                return Append(Environment.NewLine);
    }
