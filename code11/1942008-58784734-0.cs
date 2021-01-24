    //_mutex is private, readonly and exist exclusively for this operation
    lock(_mutex){
      //You only do null checks after you got a lock
      if ( paramList != null ){
        foreach ( DictionaryEntry param in paramList ) {
          command.Parameters.AddWithValue(param.Key.ToString(), param.Value);
        }
      }
    }
