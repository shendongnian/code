    public async Task<IActionResult> GetDeliveryUploadPdf(int id)
    {
        var deliveryUpload = await _context.DeliveryUploads.FindAsync(id);
        if (deliveryUpload == null)
            return NotFound();
        return File(deliveryUpload.Files, "application/pdf", "delivery-upload.pdf");
    }
