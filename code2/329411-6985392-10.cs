        static string CleanItUp(string values, params string[] removeMe)
        {
            return String.Join(";",
                       values.Split(';')
                             .Except(removeMe)
                             .ToArray());
        }
