    public class LimitExecuteIfCanCommandDecorator : CommandDecoratorBase
    {
        public LimitExecuteIfCanCommandDecorator( ICommand command ) : base( command )
        {
        }
        public override void Execute( object parameter )
        {
            if ( CanExecute(parameter) ) // check if it evaluates to true
            {
                base.Execute( parameter );
            }
        }
    }
    public abstract class CommandDecoratorBase : ICommand
    {
        protected CommandDecoratorBase(ICommand command)
        {
            _command = command;
        }
        private readonly ICommand _command;
        public event EventHandler CanExecuteChanged
        {
            add
            {
                _command.CanExecuteChanged += value;
            }
            remove
            {
                _command.CanExecuteChanged -= value;
            }
        }
        public virtual bool CanExecute( object parameter )
        {
            return _command.CanExecute( parameter );
        }
        public virtual void Execute( object parameter )
        {
            _command.Execute( parameter );
        }
    }
