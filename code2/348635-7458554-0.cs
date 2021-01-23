     var parameters = line.Split( new [] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries );
     for (var i = 0; i < parameters.Length; i += 2 )
     {
         var key = parameters[i];
         var value = int.Parse( parameters[i+1] );
         // do something with the value based on the key
     }
