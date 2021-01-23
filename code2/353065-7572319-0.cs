    public static class AbreviatorExtention
        {
    
            public static string[] GetInitials(this String str, char splitChar)
            {
                string[] initialArray = new string[3];
                var nameArray = str.Split(new char[] { splitChar },
                                StringSplitOptions.RemoveEmptyEntries);
    
                if (nameArray.Length == 2)
                {
                    var charArrayFirstName = nameArray[0].ToCharArray();
                    var charArrayLastName = nameArray[1].ToCharArray();
    
                    initialArray[0] = charArrayFirstName[0].ToString().ToUpper();
                    initialArray[1] = string.Empty;
                    initialArray[2] = charArrayLastName[0].ToString().ToUpper();
                }
                else
                {
                    for (int i = 0; i < nameArray.Length; i++)
                    {
                        initialArray[i] = (nameArray[i].ToCharArray())[1]
                                          .ToString().ToUpper();
                    }
                }
    
    
                return initialArray;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string FullName = "john doe";
    
                //Extension method in use
                string[] names = FullName.GetInitials(' ');
    
                foreach (var item in names)
                {
                    Console.WriteLine(item); 
                }
    
                Console.ReadLine();
            }
        }
