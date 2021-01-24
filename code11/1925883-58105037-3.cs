    using FORM.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    namespace FORM.Models
    {
        public class Wizard
        {
        
            public Wizard()
            {
                Progress = .2;
                Step = 1;
                SetNavButtons();
            }
            public double Progress { get; private set; }
            public int Step { get; private set; }
            public bool PreviousButtonDisabled { get; private set; }
            public bool NextButtonDisabled { get; private set; }
            public void GoToNextStep()
            {
                Step += 1;            
                Progress += .2;
                if (Step == 6)
                {
                    Progress = 100;
                }
                SetNavButtons();
            }
            public void GoToPreviousStep()
            {
                if (Step > 1)
                {
                    Step -= 1;
                    Progress -= .2;
                }
                if (Step == 1)
                {
                    Progress = .2;
                }
                SetNavButtons();
            }
            public void SetNavButtons()
            {
                NextButtonDisabled = false;
                switch (Step)
                {
                    case 1:
                        PreviousButtonDisabled = true;               
                        break;
                    case 2:
                        PreviousButtonDisabled = false;
                        break;
                    case 3:
                        PreviousButtonDisabled = false;
                        break;
                    case 4:
                        PreviousButtonDisabled = false;
                        break;
                    case 5:
                        NextButtonDisabled = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
