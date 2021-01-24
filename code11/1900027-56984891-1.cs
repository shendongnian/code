     string[] names=System.Enum.GetNames(typeof(MessageType)); 
     List<string> namesList=new List<string>(names); // to be able to use contain
     foreach(GameObject item in myGameObjectList)
          if(namesList.Contains(item.name.ToLower())
              DoStuff();
