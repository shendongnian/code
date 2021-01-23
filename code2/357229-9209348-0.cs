		PdfShading shading = PdfShading.simpleAxial(writer, 0, pageH, pageW, 0,
				BaseColor.WHITE, BaseColor.LIGHT_GRAY);
		PdfShadingPattern pattern = new PdfShadingPattern(shading);
		cb.setShadingFill(pattern);
		// cb.circle(500, 500, 500);
		cb.rectangle(0, 0, pageW, pageH);
		cb.fill();
