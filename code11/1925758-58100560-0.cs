    public IActionResult CalledAction(bool withFullDetails){
    }
    
    public IActionResult CallerAction1(){
        return RedirectToAction("CalledAction", new { withFullDetails = false });
    }
    
    public IActionResult CallerAction2(){
        return RedirectToAction("CalledAction", new { withFullDetails = true });
    }
