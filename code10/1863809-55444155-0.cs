// C++ requires declaring types before you use them.
// if we want to use Game before defining it we must at least declare that it exists.
class Game;
// this is an interface because it contains abstract (pure virtual) functions.
// you cannot create an instance of an abstract type - but you can make a reference or pointer to one.
struct IGameView
{
    // we might want polymorphic deletion - so to be safe we'll make a virtual dtor.
    virtual ~IGameView() {};
    // Game is probably expensive to copy - pass it by address (essentially by-reference).
    // = 0 makes this an abstract method, which makes this an abstract type.
    virtual void SetPresenter(Game &game) = 0;
};
// --------------------------------------------
class Game
{
public:
    // take a reference to the (interface) object to use (we can't pass an abstract type by value)
    Game(IGameView &view) : _view(view) { }
private:
    // hold a reference to the IGameView (interface) object.
    // if you ever wanted this to refer to something else this would need to be pointer instead.
    // references are kind of like pointers that cannot be repointed to something else.
    IGameView &_view;
};
class GameView : public IGameView
{
public:
    // for safety, initialize _game to null
    GameView() : _game(nullptr) {}
    // again, Game is probably expensive to copy - pass it by address.
    virtual void SetPresenter(Game &game) override
    {
        _game = &game;
    }
private:
    // hold a pointer to the Game object.
    // this has to be a pointer because SetPresenter() needs to be able to repoint it (refences can't do that).
    Game *_game;
};
// ---------------------------------------------
int main()
{
    GameView view; // create the game view to use
    Game game(view); // create the game object and use that view
    view.SetPresenter(game); // set the view to use the game object
    return 0;
}
