            foreach (PropertyInfo pi in indexProperties) {
                foreach (ParameterInfo parm in pi.GetIndexParameters()) {
                    Console.WriteLine(parm.ParameterType.ToString());
                }
                Console.WriteLine();
            }
