        //keep track of the end width right here
        static int endWidth = 0;
        public static void WordWrap(string paragraph, int tabSize = 8)
        {
            //were only doing one bit at a time
            string process = paragraph;
            List<String> wrapped = new List<string>();
            //if were going to pass the end
            while (process.Length + endWidth > Console.WindowWidth)
            {
                //reduce the wrapping in the first line by the ending with
                int wrapAt = process.LastIndexOf(' ', Math.Min(Console.WindowWidth - 1 - endWidth, process.Length));
                //if there's no space
                if (wrapAt == -1)
                {
                    //if the next bit won't take up the whole next line
                    if (process.Length < Console.WindowWidth - 1)
                    {
                        //this will give us a new line
                        wrapped.Add("");
                        //reset the width
                        endWidth = 0;
                        //stop looping
                        break;
                    }
                    else
                    {
                        //otherwise just wrap the max possible
                        wrapAt = Console.WindowWidth - 1 - endWidth;
                    }
                }
                //add the next string as normal
                wrapped.Add(process.Substring(0, wrapAt));
                //shorten the process string
                process = process.Remove(0, wrapAt + 1);
                //now reset that to zero for any other line in this group
                endWidth = 0;
            }
            //write a line for each wrapped line
            foreach (string wrap in wrapped)
            {
                Console.WriteLine(wrap);
                    
            }
            //don't write line, just write. You can add a new line later if you need it, 
            //but if you do, reset endWidth to zero
            Console.Write(process);
            //endWidth will now be the lenght of the last line.
            //if this didn't go to another line, you need to add the old endWidth
            endWidth = process.Length + endWidth;
            
        }
        //use this to end a paragraph
        static void EndParagraph()
        {
            Console.WriteLine();
            endWidth = 0;
        }
