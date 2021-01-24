c#
using(wid.Impersonate())
{
    try
    {
        throw new Exception("Something happened.");
    }
    catch(Exception e)
    {
        logger.Error(e, e.Message); // not logging.
    }
}
But
try
{
    using (wid.Impersonate())
    {
        throw new Exception("Something happened.");
    }
}
catch (Exception e)
{
    logger.Error(e, e.Message); // not logging.
}
or rethrow and log:
try
{
    using (wid.Impersonate())
    {
        try
        {
            throw new Exception("Something happened.");
        }
        catch (Exception e)
        {
            // do something;
            throw; //rethrow for logging;
        }
    }
}
catch (Exception e)
{
    logger.Error(e, e.Message); // not logging.
}
