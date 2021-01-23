    process.Start();
    var stdOutput = process.StandardOutput;
    StringBuilder fullMessage = new StringBuilder();
    while (true)
    {
        var character = (char)stdOutput.Read();
        fullMessage.Append(character);
        //Print Out All Characters
        Console.Write(character);
        if (fullMessage.ToString().EndsWith("Enter Password: "))
        {
            //Submit Password To Application
            using(StreamWriter writer = process.StandardInput){
				writer.Write("somepassword");
                writer.Flush();
			}
            break;
        }
    }
