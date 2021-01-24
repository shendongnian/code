    public class Foo { }
    public class Bar { }
    public abstract class Layout
    {
        public Bar Bar { get; set; }
        public IEnumerable<Foo> FooList { get; set; }
    }
    public class HomeViewModel : Layout
    {
    }
    public interface IFooRepository
    {
        IEnumerable<Foo> GetList();
    }
    public interface IBarRepository
    {
        Bar GetSingle();
    }
    public interface ILayoutInitializer
    {
        void Initialize(Layout layout);
    }
    public class LayoutInitializer : ILayoutInitializer
    {
        private readonly IFooRepository _fooRepository;
        private readonly IBarRepository _barRepository;
        public LayoutInitializer(IFooRepository fooRepository, IBarRepository barRepository)
        {
            _fooRepository = fooRepository;
            _barRepository = barRepository;
        }
        public void Initialize(Layout layout)
        {
            if (layout is null) throw new ArgumentNullException(nameof(layout));
            layout.FooList = _fooRepository.GetList();
            layout.Bar = _barRepository.GetSingle();
        }
    }
    public class MainController : Controller
    {
        private readonly ILayoutInitializer _layoutInitializer;
        public MainController(ILayoutInitializer layoutInitializer)
        {
            _layoutInitializer = layoutInitializer;
        }
        public IActionResult Home()
        {
            var homeViewModel = new HomeViewModel();
            _layoutInitializer.Initialize(homeViewModel);
            return View(homeViewModel);
        }
    }
