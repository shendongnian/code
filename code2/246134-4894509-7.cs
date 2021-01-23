     Public Class AnimalFarm ' My hilarious name for the FORM
         'Member variable for the currently selected instance of AnimalBase
         Private SelectedAnimal As AnimalBase
         Private Sub AnimalFarm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
             'Using the enum to populate the comboBox:
             With Me.ComboBox1.Items
                 .Add(AnimalTypes.Animal)
                 .Add(AnimalTypes.Pig)
                 .Add(AnimalTypes.Human)
             End With
         End Sub
         Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
             Dim AnimalType As AnimalTypes = Me.ComboBox1.SelectedItem
             Me.OnNewAnimalSelected(AnimalType)
         End Sub
         Private Sub OnNewAnimalSelected(ByVal AnimalType As AnimalTypes)
             SelectedAnimal = AnimalFactory.NewAnimal(AnimalType)
             'The form doesn't case what type of animal is being instantiated, so long
             'as the methods required are defined on the base class:
             MsgBox(SelectedAnimal.AnimalType.ToString)
             'Move the animal a bit, just for kicks:
             SelectedAnimal.Move(NewX, NewY)
             '  . . . But if you NEED the specific TYPE of animal:
             Select Case SelectedAnimal.AnimalType
                 Case AnimalTypes.Human
                     Dim NewHuman As Human = CType(SelectedAnimal, Human)
                     MsgBox(NewHuman.Shotgun)
                 Case AnimalTypes.Pig
                     Dim Piggy As Pig = CType(SelectedAnimal, Pig)
                     MsgBox(Piggy.PigOnEquality)
                 Case Else
                     MsgBox("This Animal has nothing to say . . .")
             End Select
         End Sub
         Private Sub OnMoveAnimal(ByVal X As Integer, ByVal Y As Integer)
             SelectedAnimal.Move(X, Y)
         End Sub
     End Class
