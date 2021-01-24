    static void executeSQL(string checkboxes)
    {
        switches checkbox_switches = new switches(checkboxes.Contains('A'), checkboxes.Contains('B'), checkboxes.Contains('C'), checkboxes.Contains('D'));
        if (checkbox_switches.action_A)
        {
            //Execute SQL
        }
        else if (checkbox_switches.action_B)
        {
            //Execute SQL
        }
        else if (checkbox_switches.action_C)
        {
            //Execute SQL
        }
        else if (checkbox_switches.action_D)
        {
            //Execute SQL
        }
        else if (checkbox_switches.action_E)
        {
            //Execute SQL
        }
    }
    struct switches
    {
        public bool action_A, action_B, action_C, action_D, action_E;
        public switches(bool A, bool B, bool C, bool D)
        {
            action_A = A && B;
            action_B = B || D;
            action_C = C && D;
            action_D = action_A && C;
            action_E = !A && !B && !C && D;
        }
    }
