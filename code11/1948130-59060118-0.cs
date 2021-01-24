MakeControl(String Type, String Name, Int Length...)
{
    ASPxTextBase tbBase = null;
   if (Type == "COMBO")
   {
        tbBase = new ASPxComboBox();
   }
   else if (Type = "DATE")
   {
        tbBase = new ASPxDateEdit();
   }
   
   tbBase.Name = Name;
   tbBase.Length = Length;
   ...
}
NOTE: I don't know the DevExpress class names so I've used dummy names in the code.
