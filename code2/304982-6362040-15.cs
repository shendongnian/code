    using System;
    using System.Windows.Input;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Windows;
    using System.Linq;
    namespace DemoApp.ViewModel
    {
        /// <summary>
        /// Represents an actionable item displayed by a View (DialogView).
        /// </summary>
        public class ModalDialogViewModel : ViewModelBase
        {
            #region Nested types
            /// <summary>
            /// Nested enum symbolizing the types of default buttons used in the dialog -> you can localize those with Localize(DialogMode, string[])
            /// </summary>
            public enum DialogMode
            {
                /// <summary>
                /// Single button in the View (default: OK)
                /// </summary>
                OneButton = 1,
                /// <summary>
                /// Two buttons in the View (default: YesNo)
                /// </summary>
                TwoButton,
                /// <summary>
                /// Three buttons in the View (default: AbortRetryIgnore)
                /// </summary>
                TreeButton,
                /// <summary>
                /// Four buttons in the View (no default translations, use Translate)
                /// </summary>
                FourButton,
                /// <summary>
                /// Five buttons in the View (no default translations, use Translate)
                /// </summary>
                FiveButton
            }
            /// <summary>
            /// Provides some default button combinations
            /// </summary>
            public enum DialogButtons
            {
                /// <summary>
                /// As System.Window.Forms.MessageBoxButtons Enumeration Ok
                /// </summary>
                Ok,
                /// <summary>
                /// As System.Window.Forms.MessageBoxButtons Enumeration OkCancel
                /// </summary>
                OkCancel,
                /// <summary>
                /// As System.Window.Forms.MessageBoxButtons Enumeration YesNo
                /// </summary>
                YesNo,
                /// <summary>
                /// As System.Window.Forms.MessageBoxButtons Enumeration YesNoCancel
                /// </summary>
                YesNoCancel,
                /// <summary>
                /// As System.Window.Forms.MessageBoxButtons Enumeration AbortRetryIgnore
                /// </summary>
                AbortRetryIgnore,
                /// <summary>
                /// As System.Window.Forms.MessageBoxButtons Enumeration RetryCancel
                /// </summary>
                RetryCancel
            }
            #endregion
            #region Members
            private static Dictionary<DialogMode, string[]> _translations = null;
            private bool _dialogShown;
            private ReadOnlyCollection<CommandViewModel> _commands;
            private string _dialogMessage;
            private string _dialogHeader;
            #endregion
            #region Class static methods and constructor
            /// <summary>
            /// Creates a dictionary symbolizing buttons for given dialog mode and buttons names with actions to berform on each
            /// </summary>
            /// <param name="mode">Mode that tells how many buttons are in the dialog</param>
            /// <param name="names">Names of buttons in sequential order</param>
            /// <param name="callbacks">Callbacks for given buttons</param>
            /// <returns></returns>
            public static Dictionary<string, Action> CreateButtons(DialogMode mode, string[] names, params Action[] callbacks) 
            {
                int modeNumButtons = (int)mode;
                if (names.Length != modeNumButtons)
                    throw new ArgumentException("The selected mode needs a different number of button names", "names");
                if (callbacks.Length != modeNumButtons)
                    throw new ArgumentException("The selected mode needs a different number of callbacks", "callbacks");
                Dictionary<string, Action> buttons = new Dictionary<string, Action>();
                for (int i = 0; i < names.Length; i++)
                {
                    buttons.Add(names[i], callbacks[i]);
                }
                return buttons;
            }
            /// <summary>
            /// Static contructor for all DialogViewModels, runs once
            /// </summary>
            static ModalDialogViewModel()
            {
                InitTranslations();
            }
            /// <summary>
            /// Fills the default translations for all modes that we support (use only from static constructor (not thread safe per se))
            /// </summary>
            private static void InitTranslations()
            {
                _translations = new Dictionary<DialogMode, string[]>();
                foreach (DialogMode mode in Enum.GetValues(typeof(DialogMode)))
                {
                    _translations.Add(mode, GetDefaultTranslations(mode));
                }
            }
            /// <summary>
            /// Creates Commands for given enumeration of Actions
            /// </summary>
            /// <param name="actions">Actions to create commands from</param>
            /// <returns>Array of commands for given actions</returns>
            public static ICommand[] CreateCommands(IEnumerable<Action> actions)
            {
                List<ICommand> commands = new List<ICommand>();
                Action[] actionArray = actions.ToArray();
                foreach (var action in actionArray)
                {
                    //RelayExecuteWrapper rxw = new RelayExecuteWrapper(action);
                    Action act = action;
                    commands.Add(new RelayCommand(x => act()));
                }
                return commands.ToArray();
            }
            /// <summary>
            /// Creates string for some predefined buttons (English)
            /// </summary>
            /// <param name="buttons">DialogButtons enumeration value</param>
            /// <returns>String array for desired buttons</returns>
            public static string[] GetButtonDefaultStrings(DialogButtons buttons)
            {
                switch (buttons)
                {
                    case DialogButtons.Ok:
                        return new string[] { "Ok" };
                    case DialogButtons.OkCancel:
                        return new string[] { "Ok", "Cancel" };
                    case DialogButtons.YesNo:
                        return new string[] { "Yes", "No" };
                    case DialogButtons.YesNoCancel:
                        return new string[] { "Yes", "No", "Cancel" };
                    case DialogButtons.RetryCancel:
                        return new string[] { "Retry", "Cancel" };
                    case DialogButtons.AbortRetryIgnore:
                        return new string[] { "Abort", "Retry", "Ignore" };
                    default:
                        throw new InvalidOperationException("There are no default string translations for this button configuration.");
                }
            }
            private static string[] GetDefaultTranslations(DialogMode mode)
            {
                string[] translated = null;
                switch (mode)
                {
                    case DialogMode.OneButton:
                        translated = GetButtonDefaultStrings(DialogButtons.Ok);
                        break;
                    case DialogMode.TwoButton:
                        translated = GetButtonDefaultStrings(DialogButtons.YesNo);
                        break;
                    case DialogMode.TreeButton:
                        translated = GetButtonDefaultStrings(DialogButtons.YesNoCancel);
                        break;
                    default:
                        translated = null; // you should use Translate() for this combination (ie. there is no default for four or more buttons)
                        break;
                }
                return translated;
            }
            /// <summary>
            /// Translates all the Dialogs with specified mode
            /// </summary>
            /// <param name="mode">Dialog mode/type</param>
            /// <param name="translations">Array of translations matching the buttons in the mode</param>
            public static void Translate(DialogMode mode, string[] translations)
            {
                lock (_translations)
                {
                    if (translations.Length != (int)mode)
                        throw new ArgumentException("Wrong number of translations for selected mode");
                    if (_translations.ContainsKey(mode))
                    {
                        _translations.Remove(mode);
                    }
                    _translations.Add(mode, translations);
                }
            }
            #endregion
            #region Constructors and initialization
            public ModalDialogViewModel(string message, DialogMode mode, params ICommand[] commands)
            {
                Init(message, Application.Current.MainWindow.GetType().Assembly.GetName().Name, _translations[mode], commands);
            }
            public ModalDialogViewModel(string message, DialogMode mode, params Action[] callbacks)
            {
                Init(message, Application.Current.MainWindow.GetType().Assembly.GetName().Name, _translations[mode], CreateCommands(callbacks));
            }
            public ModalDialogViewModel(string message, Dictionary<string, Action> buttons)
            {
                Init(message, Application.Current.MainWindow.GetType().Assembly.GetName().Name, buttons.Keys.ToArray(), CreateCommands(buttons.Values.ToArray()));
            }
            public ModalDialogViewModel(string message, string header, Dictionary<string, Action> buttons)
            {
                if (buttons == null)
                    throw new ArgumentNullException("buttons");
                ICommand[] commands = CreateCommands(buttons.Values.ToArray<Action>());
                Init(message, header, buttons.Keys.ToArray<string>(), commands);
            }
            public ModalDialogViewModel(string message, DialogButtons buttons, params ICommand[] commands)
            {
                Init(message, Application.Current.MainWindow.GetType().Assembly.GetName().Name, ModalDialogViewModel.GetButtonDefaultStrings(buttons), commands);
            }
            public ModalDialogViewModel(string message, string header, DialogButtons buttons, params ICommand[] commands)
            {
                Init(message, header, ModalDialogViewModel.GetButtonDefaultStrings(buttons), commands);
            }
            public ModalDialogViewModel(string message, string header, string[] buttons, params ICommand[] commands)
            {
                Init(message, header, buttons, commands);
            }
            private void Init(string message, string header, string[] buttons, ICommand[] commands)
            {
                if (message == null)
                    throw new ArgumentNullException("message");
                if (buttons.Length != commands.Length)
                    throw new ArgumentException("Same number of buttons and commands expected");
                base.DisplayName = "ModalDialog";
                this.DialogMessage = message;
                this.DialogHeader = header;
                List<CommandViewModel> commandModels = new List<CommandViewModel>();
                // create commands viewmodel for buttons in the view
                for (int i = 0; i < buttons.Length; i++)
                {
                    commandModels.Add(new CommandViewModel(buttons[i], commands[i]));
                }
                this.Commands = new ReadOnlyCollection<CommandViewModel>(commandModels);
            }
            #endregion
                                                                                                                                                                                                                                                                #region Properties
        /// <summary>
        /// Checks if the dialog is visible, use Show() Hide() methods to set this
        /// </summary>
        public bool DialogShown
        {
            get
            {
                return _dialogShown;
            }
            private set
            {
                _dialogShown = value;
                base.OnPropertyChanged("DialogShown");
            }
        }
        /// <summary>
        /// The message shown in the dialog
        /// </summary>
        public string DialogMessage
        {
            get
            {
                return _dialogMessage;
            }
            private set
            {
                _dialogMessage = value;
                base.OnPropertyChanged("DialogMessage");
            }
        }
        /// <summary>
        /// The header (title) of the dialog
        /// </summary>
        public string DialogHeader
        {
            get
            {
                return _dialogHeader;
            }
            private set
            {
                _dialogHeader = value;
                base.OnPropertyChanged("DialogHeader");
            }
        }
        /// <summary>
        /// Commands this dialog calls (the models that it binds to)
        /// </summary>
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                return _commands;
            }
            private set
            {
                _commands = value;
                base.OnPropertyChanged("Commands");
            }
        }
        #endregion
            #region Methods
            public void Show()
            {
                this.DialogShown = true;
            }
            public void Hide()
            {
                this._dialogMessage = String.Empty;
                this.DialogShown = false;
            }
            #endregion
        }
    }
