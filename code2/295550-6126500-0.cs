    catch(IOExceptione e){
                     Console.WriteLine("{0} System IO Exception", e);
                }
    catch(DirectoryNotFoundException e){
                 Console.WriteLine("{0} Directory not found", e);
    catch(ArgumentException e){   
                    Console.WriteLine("{0} Directory is invalid", e);
                }
              ...
