csharp
public interface IComponentView<TModel> where TModel : ComponentModel
{
    void Render(TModel componentModel);
}
csharp
public SpecialMenuView : IComponentView<SpecialMenuModel>
{
    ...
    public void Render(SpecialMenuModel componentModel)
    {
        // use model to render stuff
    }
    ...
}
You can make that interface contravariant for bonus points. 
