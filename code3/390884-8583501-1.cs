    void ChangeState(State newState)
    {
        _state = newState;
        switch (newState) {
            case State.Stopped:
                PauseButton.Image = global::GripAIConsole.Icons.Pause;
                ToolTipMainWin.SetToolTip(PauseButton, "Start game <F5>");
                break;
            case State.Pausing:
                PauseButton.Image = global::GripAIConsole.Icons.Resume;
                ToolTipMainWin.SetToolTip(PauseButton, "Resume / Step <F4>");
                break;
            case State.Running:
                PauseButton.Image = global::GripAIConsole.Icons.Pause;
                ToolTipMainWin.SetToolTip(PauseButton, "Pause <F4> / Stop game <F6>");
                break;
        }
    }
