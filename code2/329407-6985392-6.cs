        static string CleanItUp(string values, params string[] removeMe)
        {
            return String.Join(";",
                       values.Split(';')
                             .Where(x => !removeMe.Contains(x))
                             .ToArray());
        }
