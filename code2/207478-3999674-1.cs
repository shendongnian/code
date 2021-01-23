        try // 2
            something();
        catch { // A
        }
    }
    catch { // B
    }
    catch { // C
    }
    try // 1
    {
        try // 2
            something();
        catch { // A
        }
        catch { // B
        }
    }
    catch { // C
    }
