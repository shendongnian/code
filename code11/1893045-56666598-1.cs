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
 **or** if you need to change the textbox text
add this to your viewmodel
 public double Text 
 {
   get => mText;
   set 
   {
       mText = value;
       OnTextChanged();
       //notify
   }
 }
 private double mText;
 private void OnTextChanged()
 {
    //your code
 }
XAML
 <TextBox Text="{Binding Text, UpdateSourceTrigger=PropertyChanged}">
**or** if you want to have both values (x and textbox text) in one place
 <TextBlox>
    <TextBlox.Text>    
        <MultiBinding Converter="{StaticResource YOUR_MULTI_CONVERTER}"
                      UpdateSourceTrigger="PropertyChanged">
            <Binding Path="Text" />
            <Binding Path="SelectedItem.RotateTransform.Rotation.Axis.X"
                     ElementName="listOfCubes" />
        </MultiBinding>
    </TextBlox.Text>
</TextBlox>
