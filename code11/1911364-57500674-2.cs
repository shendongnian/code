    //If there is data to add
    if (temp.DATAOBJECT != null){
      FindAndReplace(_word, "<<Add-on Note LINE>>", temp.DATAOBJECT, 1);
    }else{
      range2.Find.Execute("<<Add-on Note LINE>>");
      range2.Expand(WdUnits.wdParagraph); 
      range2.MoveEnd(WdUnits.wdCharacter, -1);
      range2.Delete();
    }
