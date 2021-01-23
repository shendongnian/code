    var quartzConsumer = new QuartzConsumer(this);
    ...
    class QuartzConsumer {
        MainForm _form;
        public QuartzConsumer(MainForm form) {
            _form = form;
            ...
        }
        void OnTimer(..) {
            _form.UpdateGrid();
        }
    }
