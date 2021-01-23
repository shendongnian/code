    class View : UserControl, IView {
        CheckBox checkBox1;
        Presenter presenter;
        public string IView.Param {
            // SKIP THAT: I know I should raise an event here.
            set { presenter.Param = value; }
        }
        bool IView.Checked {
            set { checkBox1.Checked = value; }
        }
        public View() {
            presenter = new Presenter(this);
            checkBox1 = new CheckBox();
            Controls.Add(checkBox1);
        }
