csharp
public interface IHasCollectionViewModel{
  IHasCollectionView View {get;set;}
}
public interface IHasCollectionView{
  CollectionView CollectionView {get;}
}
Next, on your **View** implements **IHasCollection**
csharp
public class YourView: ContentPage, IHasCollectionView {
   CollectionView CollectionView => ScrollButtons; // your CollectionView x:Name
   protected override void OnBindingContextChanged()
   {
            if (this.BindingContext is IHasCollectionViewModel hasCollectionViewModel)
            {
                hasCollectionViewModel.View = this;
            }
            base.OnBindingContextChanged();
   }
}
Next, on your **ViewModel** implements **IHasCollectionViewModel**
csharp
public class YourViewModel: IHasCollectionViewModel {
       public IHasCollectionView View { get; set; }
       // use CollectionView like
       private void ScrollToItem(int index){
             View.CollectionView.ScrollTo(index); // don't forget check null
       }
}
Hope this helps.
