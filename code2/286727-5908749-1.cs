    private void operation_3(Stream input, TextWriter output)
    {
       input.Seek(0, SeekOrigin.Begin);  //reset stream to start of file
       TextReader inputReader = new StreamReader(input);
       
       output.Write(inputReader.ReadToEnd());
       
       inputReader.Close();
       output.Flush();
       output.Close();
    }
