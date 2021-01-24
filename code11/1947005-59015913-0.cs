public static GraphicsDeviceManager mGraphicsDeviceMgr;
This will allow access to the `mGraphicsDeviceMgr` variable from anywhere in the project:
 Game1.mGraphicsDeviceMgr.PreferredBackBufferWidth = 1600;
 Game1.mGraphicsDeviceMgr.PreferredBackBufferHeight = 900;
Due to your specific namespace choice of "Game1.Game", for completeness, the lines would need to be changed to a fully qualified name of:
 Game1.Game.Game1.mGraphicsDeviceMgr.PreferredBackBufferWidth = 1600;
 Game1.Game.Game1.mGraphicsDeviceMgr.PreferredBackBufferHeight = 900;
