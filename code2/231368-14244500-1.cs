    using System.Windows.Forms;
    
    namespace JLR.Utils
    {
        public class AnimatedDataGridView : DataGridView
        {
            private DataGridViewImageAnimator _imageAnimator;
    
            public AnimatedDataGridView()
                : base()
            {
                _imageAnimator = new DataGridViewImageAnimator(this);
            }
        }
    }
