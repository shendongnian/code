    public class DogManagedEventCollection : ManagedEventCollection<Dog>
    {
       protected override OnItemAdded (Dog dog)
       {
          dog.Bark += Bark;
       }
       protected override OnItemRemoved (Dog dog)
       {
          dog.Bark -= Bark;
       }
       
       private void Bark(object sender, BarkEventArgs ea){...}
    }
