       String s = "(Collection
                  (Item "Name1" 1 2 3)
                  (Item "Simple name2" 1 2 3)
                  (Item "Just name 3" 4 5 6))";
    
       string colection[] = s.Split('(');
       if(colection.Length>1)
       {
          for(i=1;i<colection.Length;i++)
          {
              //process string one by one and add ( if you need it
              //from the last item remove )
          }
       }
