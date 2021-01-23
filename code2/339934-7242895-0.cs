    public class GuiBehaviour : MonoBehaviour
    {
      private GUIState CurrentState;
      enum GUIState
      {
        LookInside,
        ExitView,
        GameOverView
      }
      void OnGUI(GUIState state)
      {
        CurrentState = state;
        switch(state)
        {
           case GUIState.LookInside:
             GUILayout.Button("Look Inside");
             break;
           case GUIState.ExitView:
             GUILayout.Button("Exit View");
             break;
           case GUIState.LookInside:
             GUILayout.Button("Game over");
             break;
         }
      }
    }
  
