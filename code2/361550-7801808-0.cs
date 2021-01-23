    class UserElement : StyleStingElement {
        public UserElement (User user) { ... }
        public override Selected (...)
        {
            // do your processing on 'user'
            base.Selected (dvc, tableView, indexPath);
        }
    }
