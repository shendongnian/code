       private void CharacterReplacement()
        {
            Console.WriteLine("Enter a string to replacement : ");
            string TargetString = Console.ReadLine();
            string MainString = TargetString;
            for (int i = 0; i < TargetString.Length; i++)
            {
                if (char.IsLower(TargetString[i]))
                {
                    TargetString.Replace(TargetString[i], '');
                }
            }
            Console.WriteLine("The string {0} has converted to {1}", MainString, TargetString);
    
        }
