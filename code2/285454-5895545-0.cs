    public void someFunction(int fileIndex){
    ...
       if (fileIndex == 0){
          File.Delete( "puppies.txt" );
       }
       else if (fileIndex == 1){
          File.Delete( "kittens.txt" );
       }
       else {
          throw new IllegalArgumentException( "Invalid delete index" );
       }
    }
