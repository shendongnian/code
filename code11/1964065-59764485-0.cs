    public class SpecialMenuView : IComponentView
    {
        public void Render(ComponentModel componentModel)
        {
            if (componentModel is SpecialMenuModel model)
            {
                // use model to render stuff
                model.GetType();
            }
        }
    }
