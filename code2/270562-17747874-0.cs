    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace I2c_Programmer {
        class NoSelectButton : Button{
    
                public NoSelectButton() {
    
                SetStyle(ControlStyles.Selectable, false);
    
            }
        }
    }
