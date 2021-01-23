    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    public class Info
    {
        public String Identifier;
        public char nextChar;
    };
    class testRegex {
        const string input = "Lorem ipsum dolor sit %download%#456 amet, consectetur adipiscing %download%#3434 elit. " +
        "Duis non nunc nec mauris feugiat porttitor. Sed tincidunt blandit dui a viverra%download%#298. Aenean dapibus nisl %download%#893434 id nibh auctor vel tempor velit blandit.";
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"%download%#(?<Identifier>[0-9]*)(?<nextChar>.)(?<thisCharIsNotNeeded>.)");
            List<Info> infos = new List<Info>();
            foreach (Match match in regex.Matches(input))
            {
                Info info = new Info();
                for( int i = 1; i < regex.GetGroupNames().Length; i++ )
                {
                    String groupName = regex.GetGroupNames()[i];
                    FieldInfo fi = info.GetType().GetField(regex.GetGroupNames()[i]);
                
                    if( fi != null ) // Field is non-public or does not exists.
                        fi.SetValue( info, Convert.ChangeType( match.Groups[groupName].Value, fi.FieldType));
                }
                infos.Add(info);
            }
            foreach ( var info in infos )
            {
                Console.WriteLine(info.Identifier + " followed by '" + info.nextChar.ToString() + "'");
            }
        }
    };
