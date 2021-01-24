    public abstract class Screen<T> 
    {    
        protected abstract Action GetEnterScreenAction();
        protected abstract Action GetExitScreenAction();
        protected Screen(ScreenManagerInterface screenManager){
            screenManager.SetScreenDelegates(GetEnterScreenAction(), GetExitScreenAction());
        }
    }
    public class SimpleScreen : Screen<UnityEngine.GameObject>
    {
        private void EnterScreen() { }
        private void ExitScreen() { }
        protected override Action GetEnterScreenAction() { return EnterScreen;}
        protected override Action GetExitScreenAction() { return ExitScreen;}
        SimpleScreen(ScreenManagerInterface screenManager, ....) : base(screenManager) { }
    }
    public interface ScreenManagerInterface
    {
        void SetScreenDelegates(Action enterScreenAction, Action exitScreenAction);
    }
    
