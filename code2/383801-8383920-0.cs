    if (!string.IsNullOrEmpty(controlPath))
    
{
 
       PlaceHolder1.Controls.Clear();
        UserControl uc = (UserControl)LoadControl(controlPath);
        PlaceHolder1.Controls.Add(uc);
    
