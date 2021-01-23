        private void DisplayAgents()
        {
            dgvAgents.Rows.Clear();
            foreach (Classes.Agent Agent in Classes.Collections.Agents)
            {
                DisplayAgent(Agent, false);
            }
        }
        private void DisplayAgent(Classes.Agent Agent, bool Selected)
        {
            DataGridViewRow NewRow = new DataGridViewRow();
            NewRow.Tag = Agent;
            NewRow.CreateCells(dgvAgents, new string[]
            {
                 Agent.Firstname,
                 Agent.Surname,
                 Agent.Email,
                 Agent.Admin.ToString(),
                 Agent.Active.ToString(),
            });
           
            dgvAgents.Rows.Add(NewRow);
            NewRow.Selected = Selected;
        }
