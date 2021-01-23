            int lastCommaIdx = fileLine.LastIndexOf(",");
            string agePart = fileLine.Substring(lastCommaIdx + 1, fileLine.Length - (lastCommaIdx + 1)).Trim();
            int age = Convert.ToInt32(agePart);
            fileLine = fileLine.Substring(0, lastCommaIdx);
            int dollarIdx = fileLine.LastIndexOf("$");
            string salary = fileLine.Substring(dollarIdx, fileLine.Length - dollarIdx).Trim();
            string name = fileLine.Substring(0, dollarIdx).Trim().TrimEnd(new char[1] { ',' });
            Debug.WriteLine(string.Format("Name={0}, Salary={1}, Age={2}", name, salary, age));
