    public class _HeaderModel : PageModel {
        public int? ActiveIndex { get; set; }
        public _HeaderModel() { }
        public _HeaderModel(int? activeIndex) {
            this.ActiveIndex = activeIndex;
        }
    }
