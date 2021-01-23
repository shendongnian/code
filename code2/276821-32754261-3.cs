    private Boolean pulseOn;
    private void operationsOfMaintenance_OperationExpired(Boolean state)
            {
                Storyboard storyBoardPulse = this.FindResource("StoryboardMainIconPulse") as Storyboard;
                Storyboard.SetTarget(storyBoardPulse, this.imageIcon);
                if (!state)
                {
                    storyBoardPulse.Stop();
                    storyBoardPulse.Remove();
                    pulseOn = false;
                }
                else
                {
                    if(!pulseOn)storyBoardPulse.Begin();
                    pulseOn = true;
                }
            }
