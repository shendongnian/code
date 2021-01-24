    public class OperandTreeNodeController
    {
        private Requirement m_model;
        private TreeNode m_view;
        public OperandTreeNodeController(Requirement model, TreeNode view)
        {
            m_model = model;
            m_view = view;
            m_model.PropertyChanged += Model_PropertyChanged;
        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            m_view.Text = m_model.ToString();
        }
    }
