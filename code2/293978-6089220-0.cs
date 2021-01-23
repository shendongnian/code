    //CLIENT
    //Makes an array to hold stream content
    var bb = new byte[stm.Length];
    //Fill the array with the stream content
    stm.Read(bb, 0, (int)stm.Length);
    //Converts the array of bytes back to a string
    var rcvString = System.Text.UTF8Encoding.UTF8.GetString(bb);
    //Split the string into an array using "," as separator
    var array = rcvString.Split(new string[]{","}, 
        StringSplitOptions.RemoveEmptyEntries);
    var pad = 2;   
    var inc = 20;
    var max = array.Length;
    //Iterates through the array in "inc" intervals                        
    for (var i = 0; i < max; i+=inc)
    {
        //Iterates through a section of the array determined by "i" and "inc" 
        //(there is a special case if "inc" it's not a multiple of max)
        for (var j = 0; j < (max - i > inc ? inc : max - i); j += 1)
        {
            Console.Write(String.Format(@" {0}",array[i + j].PadLeft(pad)));
        }
        Console.Write('\n');
    }
