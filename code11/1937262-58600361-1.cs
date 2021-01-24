<CheckBox IsChecked="{Binding falta_justificada, Mode=TwoWay}" Grid.Column="1" HorizontalOptions="Start" Color="DarkBlue" AutomationId="{Binding idalumno_grupo}"/>
###ViewModel
//...
foreach(AsistenciaList asistencia in ListaAsistencia)
{
   asistencia.PropertyChanged += Asistencia_PropertyChanged;
}
//...
private void Asistencia_PropertyChanged(object sender, PropertyChangedEventArgs e)
{
   if(e.PropertyName== "falta_justificada")
   {
     AsistenciaList asistencia = sender as AsistenciaList;
     var idalumno_grupo = asistencia.idalumno_grupo;
     //...do something you want
   }
}
