    public class Host {
    
       HostEventDispatcher dispatcher = new HostEventDispatcher ();
       MenuTypes {File, Tools, Options, Help}
       ToolBarTypes {MainBar}
    
       AddSubMenuToMainMenu(IMenu menu, MenuTypes hostMenu);
       AddSubMenuToMainMenu(IToolbar toolbar, ToolBarTypes hostToolbar);   
    
       public void LoadPlugin(IPlugin plugin) 
       {
           plugin.Dispatcher = dispatcher;
       }
    }
    
    interface IMenu {/* control warpper implementation */} 
    
    interface IToolBar {/* control wrapper implementation */}
    
    public HostEventDispatcher {
       //raises events to subscribers (Host, plugins)
    
       /***** event list ***/
    }
    
    public interface IPlugin 
    {
        Dispatcher {get;set} //using this plugin can raise/recieve evets to/from Host.
    }
