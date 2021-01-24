 public double X 
 {
   get => mX;
   set 
   {
       mX = value;
       OnXChanged();
       //notify
   }
 }
 private double mX;
 private void OnXChanged()
 {
    //your code
 }
then bind it like this, **DONT FORGET ->** `UpdateSourceTrigger=PropertyChanged`
 <TextBox Text="{Binding SelectedItem.RotateTransform.Rotation.Axis.X,
                         ElementName=listOfCubes,
                         UpdateSourceTrigger=PropertyChanged}">
