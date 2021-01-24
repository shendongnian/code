    public KeyCode keyCode; //Select DIFFERENT KeyCodes for each team in the Inspector
                            //For example, Team A = KeyCode.A, Team B = KeyCode.B, etc
        public scr_CreateTeams thisTeam;
    
        void Update()
        {
            if (Input.GetButtonDown(keyCode))
            {
                MyTeamProfile.teamname = thisTeam.teamname;
            }
        }
