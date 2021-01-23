    //****************************************************************************************
    // WpfPrint
    //
    // Various helpers for printing WPF UI to a printer
    //****************************************************************************************
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Documents;
    using System.Windows.Markup;
    using System.Windows.Controls;
    using System.Windows.Xps;
    using System.Windows;
    using System.Printing;
    using System.Windows.Media;
    namespace csheet
    {
        /// <summary>
        /// Various helpers for printing WPF UI to a printer
        /// </summary>
        public class WpfPrint
        {
            #region Supporting Types
            //****************************************************************************************
            // Suporting Types
            //****************************************************************************************
            /// <summary>
            /// Element flags define the way the elements print; OR them for multiple effects
            /// </summary>
            [Flags]
            public enum ElementFlags
            {
                /// <summary>No special flags</summary>
                None = 0,
                /// <summary>Move to the next line after output</summary>
                NewLine = 1,
                /// <summary>if there isn't 2x room, then do new page first</summary>
                BottomCheck2 = 2,
                /// <summary>Center the item horizontally</summary>
                HorzCenter = 4,
                /// <summary>Right align the item (center overrides)</summary>
                HorzRight = 8
            }
            #endregion Supporting Types
            #region Data
            //****************************************************************************************
            // Data
            //****************************************************************************************
            FixedDocument _fixedDocument;
            FixedPage _curFixedPage;
            Canvas _curCanvas;
            double _marginX;
            double _marginY;
            Size _infiniteSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
            #endregion Data
            #region Properties
            //****************************************************************************************
            // Properties
            //****************************************************************************************
            /// <summary>Current font family used for known objects</summary>
            public FontFamily CurrentFontFamily { get; set; }
            /// <summary>Current font size used for known objects</summary>
            public double CurrentFontSize { get; set; }
            /// <summary>Current font weight used for known objects</summary>
            public FontWeight CurrentFontWeight { get; set; }
            /// <summary>Current font style used for known objects</summary>
            public FontStyle CurrentFontStyle { get; set; }
            /// <summary>Current margin for known objects</summary>
            public Thickness CurrentElementMargin { get; set; }
            /// <summary>Current background for known objects</summary>
            public Brush CurrentElementBackground { get; set; }
            /// <summary>Current foreground for known objects</summary>
            public Brush CurrentElementForeground { get; set; }
            /// <summary>Gets the current fixed document being worked on</summary>
            public FixedDocument CurrentFixedDocument
            {
                get { return _fixedDocument; }
            }
            /// <summary>The current horizontal position</summary>
            public double CurX { get; set; }
            /// <summary>The current vertical position</summary>
            public double CurY { get; set; }
            /// <summary>The starting and ending X margins on the page</summary>
            public double MarginX
            {
                get { return _marginX; }
                set
                {
                    if (value < 0)
                        value = 0;
                    _marginX = value;
                    if (CurX < _marginX)
                        CurX = _marginX;
                }
            }
            /// <summary>The starting and ending Y margins on the page</summary>
            public double MarginY
            {
                get { return _marginY; }
                set
                {
                    if (value < 0)
                        value = 0;
                    _marginY = value;
                    if (CurY < _marginY)
                        CurY = _marginY;
                }
            }
            /// <summary>Gets the page size for the document minus the margins</summary>
            public Size PageSizeUsed
            {
                get
                {
                    Size sz = CurrentFixedDocument.DocumentPaginator.PageSize;
                    sz.Width -= 2 * _marginX;
                    sz.Height -= 2 * _marginY;
                    return sz;
                }
            }
            #endregion Properties
            #region Construction
            //****************************************************************************************
            // Construction
            //****************************************************************************************
            /// <summary>
            /// Constructor for printing
            /// </summary>
            /// <param name="printQueue"></param>
            /// <param name="printTicket"></param>
            public WpfPrint(PrintQueue printQueue, PrintTicket printTicket)
            {
                PrintCapabilities capabilities = printQueue.GetPrintCapabilities(printTicket);
                Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
                _fixedDocument = new FixedDocument();
                _fixedDocument.DocumentPaginator.PageSize = sz;
                StartPage();
            }
            /// <summary>
            /// Constructor for XPS creation
            /// </summary>
            /// <param name="sz"></param>
            public WpfPrint(Size sz)
            {
                _fixedDocument = new FixedDocument();
                _fixedDocument.DocumentPaginator.PageSize = sz;
                StartPage();
            }
            #endregion Construction
            #region Interfaces
            //****************************************************************************************
            // Interfaces
            //****************************************************************************************
            /// <summary>
            /// Add a new page to the document (start a new page)
            /// </summary>
            public void StartPage()
            {
                // Create a new page content and fixed page
                PageContent content = new PageContent();
                _fixedDocument.Pages.Add(content);
                _curFixedPage = new FixedPage();
                ((IAddChild)content).AddChild(_curFixedPage);
                // Create a new drawing canvas for the page
                _curCanvas = new Canvas();
                _curCanvas.Width = _fixedDocument.DocumentPaginator.PageSize.Width;
                _curCanvas.Height = _fixedDocument.DocumentPaginator.PageSize.Height;
                _curFixedPage.Children.Add(_curCanvas);
                // Reset the current position
                CurX = MarginX;
                CurY = MarginY;
            }
            /// <summary>
            /// Adds a new element at the current position, and updates the current position
            /// </summary>
            /// <param name="element">New element to add</param>
            /// <param name="flags">Print options</param>
            public void AddUIElement(UIElement element, ElementFlags flags)
            {
                element.Measure(_infiniteSize);
                if (CurX > _fixedDocument.DocumentPaginator.PageSize.Width - MarginX)
                {
                    CurY += element.DesiredSize.Height;
                    CurX = MarginX;
                }
                double extraCheck = 0;
                if ((flags & ElementFlags.BottomCheck2) == ElementFlags.BottomCheck2)
                    extraCheck = element.DesiredSize.Height;
                if (CurY > _fixedDocument.DocumentPaginator.PageSize.Height - MarginY - extraCheck)
                    StartPage();
                _curCanvas.Children.Add(element);
                element.SetValue(Canvas.LeftProperty, CurX);
                element.SetValue(Canvas.TopProperty, CurY);
                CurX += element.DesiredSize.Width;
                if ((flags & ElementFlags.NewLine) == ElementFlags.NewLine)
                {
                    CurX = MarginX;
                    CurY += element.DesiredSize.Height;
                }
            }
            /// <summary>
            /// Add a current style TextBlock element at the current position
            /// </summary>
            /// <param name="text">Text to add</param>
            /// <param name="width">Width of element</param>
            /// <param name="height">Height of element</param>
            /// <param name="flags">Print options</param>
            public void AddTextBlock(string text, double width, double height, ElementFlags flags)
            {
                TextBlock tb = new TextBlock();
                tb.Text = text;
                tb.FontFamily = CurrentFontFamily;
                tb.FontSize = CurrentFontSize;
                tb.FontWeight = CurrentFontWeight;
                tb.FontStyle = CurrentFontStyle;
                tb.VerticalAlignment = VerticalAlignment.Center;
                if ((flags & ElementFlags.HorzCenter) == ElementFlags.HorzCenter)
                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                else if ((flags & ElementFlags.HorzRight) == ElementFlags.HorzRight)
                    tb.HorizontalAlignment = HorizontalAlignment.Right;
                tb.Margin = CurrentElementMargin;
                if (CurrentElementForeground != null)
                    tb.Foreground = CurrentElementForeground;
                if (CurrentElementBackground != null)
                    tb.Background = CurrentElementBackground;
                Grid grid = new Grid();
                if (CurrentElementBackground != null)
                    grid.Background = CurrentElementBackground;
                if (width != 0)
                    grid.Width = width;
                if (height != 0)
                    grid.Height = height;
                grid.Children.Add(tb);
                AddUIElement(grid, flags);
            }
            /// <summary>
            /// Adds a current style TextBox element at the current position
            /// </summary>
            /// <param name="text">Text to add</param>
            /// <param name="width">Width of element</param>
            /// <param name="height">Height of element</param>
            /// <param name="flags">Print options</param>
            public void AddTextBox(string text, double width, double height, ElementFlags flags)
            {
                TextBox tb = new TextBox();
                tb.Text = text;
                tb.FontFamily = CurrentFontFamily;
                tb.FontSize = CurrentFontSize;
                tb.FontWeight = CurrentFontWeight;
                tb.FontStyle = CurrentFontStyle;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.VerticalContentAlignment = VerticalAlignment.Center;
                if ((flags & ElementFlags.HorzCenter) == ElementFlags.HorzCenter)
                    tb.HorizontalContentAlignment = HorizontalAlignment.Center;
                else if ((flags & ElementFlags.HorzRight) == ElementFlags.HorzRight)
                    tb.HorizontalContentAlignment = HorizontalAlignment.Right;
                tb.Margin = CurrentElementMargin;
                if (CurrentElementBackground != null)
                    tb.Background = CurrentElementBackground;
                if (CurrentElementForeground != null)
                    tb.Foreground = CurrentElementForeground;
                Grid grid = new Grid();
                if (CurrentElementBackground != null)
                    grid.Background = CurrentElementBackground;
                if (width != 0)
                    grid.Width = width;
                if (height != 0)
                    grid.Height = height;
                grid.Children.Add(tb);
                AddUIElement(grid, flags);
            }
            /// <summary>
            /// Add a current style CheckBox element at the current position
            /// </summary>
            /// <param name="value">Checkbox value to add</param>
            /// <param name="width">Width of element</param>
            /// <param name="height">Height of element</param>
            /// <param name="flags">Print options</param>
            public void AddCheckBox(bool value, double width, double height, ElementFlags flags)
            {
                CheckBox cb = new CheckBox();
                cb.IsChecked = value;
                cb.VerticalAlignment = VerticalAlignment.Center;
                if ((flags & ElementFlags.HorzCenter) == ElementFlags.HorzCenter)
                    cb.HorizontalAlignment = HorizontalAlignment.Center;
                else if ((flags & ElementFlags.HorzRight) == ElementFlags.HorzRight)
                    cb.HorizontalAlignment = HorizontalAlignment.Right;
                if (CurrentElementForeground != null)
                    cb.Foreground = CurrentElementForeground;
                if (CurrentElementBackground != null)
                    cb.Background = CurrentElementBackground;
                Grid grid = new Grid();
                if (CurrentElementBackground != null)
                    grid.Background = CurrentElementBackground;
                if (width != 0)
                    grid.Width = width;
                if (height != 0)
                    grid.Height = height;
                grid.Children.Add(cb);
                AddUIElement(grid, flags);
            }
            #endregion Interfaces
        }
    }
