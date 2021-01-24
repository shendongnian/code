csharp
public class Booter
    {
        public static IContainer BootStrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FilesService>()
              .As<IFilesService>().SingleInstance();
            builder.RegisterType<ControlsService>()
              .As<IControlsService>().SingleInstance();
            builder.RegisterType<Facade>()
              .AsSelf().SingleInstance();
            return builder.Build();
        }
    }
Into facade we are injecting library dependencies:
csharp
public class Facade
    {
        IFilesService _fileService;
        IControlsService _controlsService;
        public Facade(IFilesService filesService, IControlsService controlsService)
        {
            _fileService = filesService;
            _controlsService = controlsService;
            FilesService = _fileService;
            ControlsService = _controlsService;
        }
        public IFilesService FilesService { get; }
        public IControlsService ControlsService { get; }
    }
Next, in our lib, at first need to call `Initialize`, and `Resolve` inside facade, and to interfaces we declare facade properties that they are actually injected services:
csharp
public class MainService : IMainService
    {
        IFilesService _fileService;
        IControlsService _controlsService;
        IContainer _container;
        public MainService()
        {
            Initialize();
        }
        public void Initialize()
        {
            _container = Booter.BootStrap();
            var aggregator = _container.Resolve<Facade>();
            _fileService = aggregator.FilesService;
            _controlsService = aggregator.ControlsService;
        }
        public UiControlsModel SwitchOff()
        {
            return _controlsService.SwitchOff();
        }
        public UiControlsModel SwitchOn()
        {
            return _controlsService.SwitchOn();
        }
    }
I really hope that it is not any anti-pattern.
