    using (StreamReader inputFile = File.OpenText("students.txt"))
            {
                while (!inputFile.EndOfStream)
                {
                    PersonEntry person = new PersonEntry();
                    person.Name = inputFile.ReadLine();
                    person.AverageScore = inputFile.ReadLine();
                    person.LetterGrade = inputFile.ReadLine();
                }
            }
            using (StreamWriter outputFile = File.CreateText("students.txt"))
            {
                // Write the info to the file. 
                outputFile.WriteLine(nameTextBox.Text);
                outputFile.WriteLine(average);
                outputFile.WriteLine("F");
                outputFile.Close();
            }
