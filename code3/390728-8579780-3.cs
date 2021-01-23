            string line;//The line that is read.
            string previousLine = "0 0";
            int prevTime = 0;
            //These "using"'s are so that the resources they use will be freed when the block ( i.e. {} ) is finished.
            using (System.IO.StreamReader originalFile = new System.IO.StreamReader("c:\\users\\Me\\t.txt"))
            using (System.IO.StreamWriter newFile = new System.IO.StreamWriter("c:\\users\\Me\\t2.txt"))
            {
                while ((line = originalFile.ReadLine()) != null)
                {
                    //"Split" changes the words in "line" (- that are separated by a space) to an array. 
                    //"Parse" takes the first in that array (by using "[0]") and changes it into an integer.
                    int time = int.Parse(line.Split(' ')[0]);
                    while (prevTime != 0 && time > ++prevTime) newFile.WriteLine(prevTime.ToString() + " " + previousLine.Split(' ')[1]);
                    
                    previousLine = line;
                    prevTime = time;
                    newFile.WriteLine(line);
                }
            }
