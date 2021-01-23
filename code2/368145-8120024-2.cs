    /// <summary>
    /// Defines how a dockable content can be dragged over a docking manager
    /// </summary>
    /// <remarks>This style can be composed with the 'or' operator.</remarks>
    public enum DockableStyle : uint
    { 
        /// <summary>
        /// Content is not dockable at all
        /// </summary>
        None = 0x0000,
    
        /// <summary>
        /// Dockable as document
        /// </summary>
        Document    = 0x0001,
    
        /// <summary>
        /// Dockable to the left border of <see cref="DockingManager"/>
        /// </summary>
        LeftBorder  = 0x0002,
    
        /// <summary>
        /// Dockable to the right border of <see cref="DockingManager"/>
        /// </summary>
        RightBorder = 0x0004,
    
        /// <summary>
        /// Dockable to the top border of <see cref="DockingManager"/>
        /// </summary>
        TopBorder   = 0x0008,
    
        /// <summary>
        /// Dockable to the bottom border of <see cref="DockingManager"/>
        /// </summary>
        BottomBorder= 0x0010,
    
        /// <summary>
        /// A <see cref="DockableContent"/> with this style can be hosted in a <see cref="FloatingWindow"/>
        /// </summary>
        Floating = 0x0020,
            
        /// <summary>
        /// A <see cref="DockableContent"/> with this style can be the only one content in a <see cref="DockablePane"/> pane (NOT YET SUPPORTED)
        /// </summary>
        /// <remarks>This style is not compatible with <see cref="DockableStyle.Document"/> style</remarks>
        Single = 0x0040,
    
        /// <summary>
        /// A <see cref="DockableContet"/> with this style can be autohidden.
        /// </summary>
        AutoHide = 0x0080,
    
        /// <summary>
        /// Dockable only to a border of a <see cref="DockingManager"/>
        /// </summary>
        DockableToBorders = LeftBorder | RightBorder | TopBorder | BottomBorder | AutoHide,
            
        /// <summary>
        /// Dockable to a border of a <see cref="DockingManager"/> and into a <see cref="DocumentPane"/>
        /// </summary>
        Dockable = DockableToBorders | Document | Floating,
    
        /// <summary>
        /// Dockable to a border of a <see cref="DockingManager"/> and into a <see cref="DocumentPane"/> but not in autohidden mode (WinForms controls)
        /// </summary>
        DockableButNotAutoHidden = Dockable & ~AutoHide
    }
