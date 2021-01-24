    public abstract class Screen<T> 
    {    
        protected abstract Action GetEnterScreenAction();
        protected abstract Action GetExitScreenAction();
        public Screen(ScreenManagerInterface screenManager)
        {
            screenManager.SetScreenActions(GetEnterScreenAction(), GetExitScreenAction());
        }
    }
    public class SimpleScreen : Screen<UnityEngine.GameObject>
    {
        private void EnterScreen() { }
        private void ExitScreen() { }
        protected override Action GetEnterScreenAction() { return EnterScreen;}
        protected override Action GetExitScreenAction() { return ExitScreen;}
        public SimpleScreen(ScreenManagerInterface screenManager, ....) : base(screenManager) { }
    }
    public interface ScreenManagerInterface
    {
        void SetScreenActions(Action enterScreenAction, Action exitScreenAction);
    }
    
